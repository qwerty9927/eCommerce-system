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
            .join("") +
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

function validateDeliveryInfo() {
    const fName = document.getElementById("c_fname").value.trim();
    const LName = document.getElementById("c_lname").value.trim();
    const address = document.getElementById("c_address").value.trim();
    const phone = document.getElementById("c_phone").value.trim();

    // Clear previous error messages
    document
        .querySelectorAll(".error-message")
        .forEach((error) => (error.textContent = ""));

    let isValid = true;

    // Validate First Name
    if (!fName) {
        document.getElementById("error-fname").textContent =
            "First name is required.";
        isValid = false;
    }

    // Validate Last Name
    if (!LName) {
        document.getElementById("error-lname").textContent =
            "Last name is required.";
        isValid = false;
    }

    // Validate Address
    if (!address) {
        document.getElementById("error-address").textContent =
            "Address is required.";
        isValid = false;
    }

    // Validate Phone
    const phonePattern = /^[0-9]{10,15}$/; // Validate phone number (10-15 digits)
    if (!phone || !phonePattern.test(phone)) {
        document.getElementById("error-phone").textContent =
            "Enter a valid phone number.";
        isValid = false;
    }

    return isValid;
}

async function stripeComponent(publicKey) {
    const stripe = Stripe(publicKey);
    const elements = stripe.elements();
    const cardElement = elements.create("card");
    cardElement.mount("#card-element");

    const placeOrderEle = document.getElementById("place-order");
    placeOrderEle.addEventListener("click", async (event) => {
        event.preventDefault();
        if (!validateDeliveryInfo()) {
            return;
        }

        const cardErrors = document.getElementById("card-errors");
        const { source, error } = await stripe.createSource(cardElement, {
            type: "card",
        });
        if (error) {
            console.error("Error creating source:", error);
            cardErrors.textContent = error.message;
        } else {
            console.log("Source created:", source);
            await mockup({
                sourceId: source.id,
                deliveryInformation: {
                    firstName: document.getElementById("c_fname").value.trim(),
                    lastName: document.getElementById("c_lname").value.trim(),
                    AddressDetail: document
                        .getElementById("c_address")
                        .value.trim(),
                    phoneNumber: document
                        .getElementById("c_phone")
                        .value.trim(),
                },
            });
            window.location.href = "/home/thankyou";
        }
    });
}

async function mockup(data) {
    const url = `${Constant.UrlApi}api/order/mock-up`;
    try {
        const response = await postApiAsync(url, data);
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
