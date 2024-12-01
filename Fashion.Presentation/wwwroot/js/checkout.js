import { postApi } from "./helper.js";

function stripeComponent(publicKey) {
    const stripe = Stripe(publicKey);
    const elements = stripe.elements();
    const cardElement = elements.create("card");
    cardElement.mount("#card-element");

    const form = document.getElementById("payment-form");
    form.addEventListener("submit", async (event) => {
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
            postApi(source.id);
        }
    });
}

export { stripeComponent };
