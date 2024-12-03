import Constant from "./constant.js";
import { getApiAsync, putApiAsync } from "./helper.js";

async function getCart() {
    const url = `${Constant.UrlApi}api/cart/summary`;
    try {
        const response = await getApiAsync(url);
        console.log(response);

        if (!response.status) {
            return;
        }

        render(response.data);
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

function render(data) {
    const cartItem = document.getElementById("cart-item");
    const cartTotal = document.getElementById("cart-total");

    const cartDetails = data.cartDetails;

    cartItem.innerHTML = cartDetails.map((item) => {
        return `<tr>
                    <td class="product-thumbnail">
                      <img src="images/cloth_2.jpg" alt="Image" class="img-fluid">
                    </td>
                    <td class="product-name">
                      <h2 class="h5 text-black">${item.product.productName}</h2>
                    </td>
                    <td>$${item.size.price}.00</td>
                    <td>
                      <div class="input-group mb-3" style="max-width: 120px;">
                        <div class="input-group-prepend">
                          <button class="btn btn-outline-primary js-btn-minus decrease-item" type="button" data-cartDetailId="${
                              item.id
                          }">&minus;</button>
                        </div>
                        <input type="text" class="form-control text-center" value="${
                            item.quantity
                        }" placeholder="" aria-label="Example text with button addon" aria-describedby="button-addon1">
                        <div class="input-group-append">
                          <button class="btn btn-outline-primary js-btn-plus increase-item" type="button" data-productId="${
                              item.product.id
                          }" data-sizeId="${item.size.id}">&plus;</button>
                        </div>
                      </div>

                    </td>
                    <td>$${item.quantity * item.size.price}.00</td>
                    <td><a href="#" class="btn btn-primary btn-sm remove-item" data-cartDetailId="${
                        item.id
                    }">X</a></td>
                  </tr>`;
    });

    cartTotal.innerHTML = `
                <div class="row mb-3">
                    <div class="col-md-6">
                      <span class="text-black">Subtotal</span>
                    </div>
                    <div class="col-md-6 text-right">
                      <strong class="text-black">$${data.subTotal}.00</strong>
                    </div>
                  </div>
                  <div class="row mb-5">
                    <div class="col-md-6">
                      <span class="text-black">Total</span>
                    </div>
                    <div class="col-md-6 text-right">
                      <strong class="text-black">$${data.total}.00</strong>
                    </div>
                  </div>`;

    const decreaseItemEles = document.getElementsByClassName("decrease-item");
    const increaseItemEles = document.getElementsByClassName("increase-item");
    const removeItemEles = document.getElementsByClassName("remove-item");

    Array.from(decreaseItemEles).forEach((ele) => {
        const cartDetailId = ele.getAttribute("data-cartDetailId");
        console.log(cartDetailId);
        ele.onclick = async (e) => await decreaseItem(e, cartDetailId, 1);
    });

    Array.from(removeItemEles).forEach((ele) => {
        const cartDetailId = ele.getAttribute("data-cartDetailId");
        console.log(cartDetailId);
        ele.onclick = async (e) => await decreaseItem(e, cartDetailId, 9999);
    });

    Array.from(increaseItemEles).forEach((ele) => {
        const productId = ele.getAttribute("data-productId");
        const sizeId = ele.getAttribute("data-sizeId");

        ele.onclick = async (e) => await increaseItem(e, productId, sizeId, 1);
    });
}

async function decreaseItem(e, cartDetailId, quantity) {
    const url = `${Constant.UrlApi}api/cart/remove`;
    try {
        const response = await putApiAsync(url, {
            cartDetailId,
            quantity,
        });
        console.log(response);

        if (!response.status) {
            return;
        }

        await getCart();
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

async function increaseItem(e, productId, sizeId, quantity) {
    const url = `${Constant.UrlApi}api/cart/add`;
    try {
        const response = await putApiAsync(url, {
            productId,
            sizeId,
            quantity,
        });
        console.log(response);

        if (!response.status) {
            return;
        }

        await getCart();
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

async function cart() {
    await getCart();
}

export default cart;
