import { getApiAsync, postApiAsync } from "./helper.js";
import Constant from "./constant.js";

async function getUserInfo() {
    const userInfo = document.getElementById("user-info");
    const url = `${Constant.UrlApi}api/account`;
    try {
        const response = await getApiAsync(url);
        console.log(response);

        if (!response.status) {
            return;
        }

        const data = response.data;

        userInfo.innerHTML = `
                <div class="col-md-3 text-center mb-5">
                  <div class="avatar avatar-xl">
                    <img src="../dashboard/assets/avatars/face-1.jpg" alt="..." class="avatar-img rounded-circle">
                  </div>
                </div>
                <div class="col">
                  <div class="row align-items-center">
                    <div class="col-md-7">
                      <h4 class="mb-1">${data.fullName}</h4>
                      <p class="small mb-3"><span class="badge badge-dark">New York, USA</span></p>
                    </div>
                  </div>
                  <div class="row mb-4">
                    <div class="col-md-7">
                      <p class="text-muted"> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit nisl ullamcorper, rutrum metus in, congue lectus. In hac habitasse platea dictumst. Cras urna quam, malesuada vitae risus at, pretium blandit sapien. </p>
                    </div>
                    <div class="col">
                      <p class="small mb-0 text-muted">Nec Urna Suscipit Ltd</p>
                      <p class="small mb-0 text-muted">P.O. Box 464, 5975 Eget Avenue</p>
                      <p class="small mb-0 text-muted">(537) 315-1481</p>
                    </div>
                  </div>
                </div>`;
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

async function getMyOrder() {
    const colorPicker = {
        pending: "bg-primary",
        succeed: "bg-success",
    };
    const orders = document.getElementById("orders");
    const url = `${Constant.UrlApi}api/order`;
    try {
        const response = await getApiAsync(url);
        console.log(response);

        if (!response.status) {
            return;
        }

        const data = response.data;

        orders.innerHTML = data
            .map((d) => {
                return `
                <tr>
                    <td class="text-center align-middle">
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="checkbox${
                            d.id
                        }">
                        <label class="form-check-label" for="checkbox${
                            d.id
                        }"></label>
                        </div>
                    </td>
                    <td class="align-middle">${d.id}</td>
                    <td class="align-middle">${new Date(
                        d.createdAt
                    ).toLocaleString("en-US", { timeZone: "UTC" })}</td>
                    <td class="align-middle">${new Date(
                        d.updatedAt
                    ).toLocaleString("en-US", {
                        timeZone: "UTC",
                    })}</td>
                    <td class="align-middle">$${d.total.toFixed(2)}</td>
                    <td class="align-middle">
                        <span class="badge">Visa</span>
                    </td>
                    <td class="align-middle">
                        <span class="dot dot-lg ${
                            colorPicker[d.status.toLowerCase()]
                        } me-2"></span>
                        ${d.status}
                    </td>
                    <td class="align-middle">
                        ${
                            d.status.toLowerCase() !== "succeed"
                                ? `<a href="#" data-orderId="${d.id}" class="btn btn-sm btn-outline-success confirm-order">Confirm</a>`
                                : ""
                        }
                        
                    </td>
                </tr>`;
            })
            .join("");

        confirmOrder();
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

async function confirmOrder() {
    const confirmOrderEle = document.getElementsByClassName("confirm-order");
    confirmOrderEle.forEach((ele) => {
        ele.onclick = async (e) => {
            const orderId = ele.getAttribute("data-orderId");
            console.log(orderId);
            const url = `${Constant.UrlApi}api/order/confirm-payment`;
            try {
                const response = await postApiAsync(url, orderId);
                console.log(response);

                if (!response.status) {
                    return;
                }

                await getMyOrder();
            } catch (error) {
                console.error("An error occurred:", error);
            }
        };
    });
}

function dashboard(route) {
    switch (route) {
        case "order":
            getMyOrder();
            break;
        default:
            getUserInfo();
            break;
    }
}

export default dashboard;
