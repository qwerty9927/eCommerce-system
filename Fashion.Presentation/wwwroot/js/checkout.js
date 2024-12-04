import Constant from "./constant.js";
import { postApiAsync, getApiAsync } from "./helper.js";

async function getCartSummary() {
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
    const orderDetail = document.getElementById("order-detail");

    const cartDetails = data.cartDetails;

    orderDetail.innerHTML =
        cartDetails
            .map((item) => {
                return `<tr>
                    <td>${
                        item.product.productName
                    }<strong class="mx-2"> x </strong>${item.quantity}</td>
                    <td>$${(item.quantity * item.size.price).toFixed(2)}</td>
                </tr>`;
            })
            .join("") + // Combine all rows into a single string
        `<tr>
            <td class="text-black font-weight-bold"><strong>Cart Subtotal</strong></td>
            <td class="text-black">$${data.total.toFixed(2)}</td>
        </tr>
        <tr>
            <td class="text-black font-weight-bold"><strong>Order Total</strong></td>
            <td class="text-black font-weight-bold"><strong>$${data.total.toFixed(
                2
            )}</strong></td>
        </tr>`;
}

async function stripeComponent(publicKey) {
    const stripe = Stripe(publicKey);
    const elements = stripe.elements();
    const cardElement = elements.create("card");
    cardElement.mount("#card-element");

    const placeOrderEle = document.getElementById("place-order");
    placeOrderEle.addEventListener("click", async (event) => {
        event.preventDefault();
        const cardErrors = document.getElementById("card-errors");
        const { source, error } = await stripe.createSource(cardElement, {
            type: "card",
        });
        if (error) {
            console.error("Error creating source:", error);
            cardErrors.textContent = error.message;
        } else {
            console.log("Source created:", source);
            await mockup(source.id);
            window.location.href = "/home/thankyou";
        }
    });
}

async function mockup(sourceId) {
    const url = `${Constant.UrlApi}api/order/mock-up`;
    try {
        const response = await postApiAsync(url, sourceId);
        console.log(response);

        if (!response.status) {
            return;
        }
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

async function checkout() {
    const publicKey =
        "pk_test_51QR2Oe4gFB9qz1SHSUdv80XGvZMlVXHvkn1oTtZOPD0PZIRTgEwSr12pfAwzvfzwy5EU0vECRMTkDoM3gfb8fYPq00xe19tt8h";

    getCartSummary();
    await stripeComponent(publicKey);
}
export default checkout;
