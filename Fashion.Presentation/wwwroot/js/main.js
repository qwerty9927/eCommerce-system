import { stripeComponent } from "./checkout.js";
import init from "./init.js";

function main() {
    const publicKey =
        "pk_test_51QR2Oe4gFB9qz1SHSUdv80XGvZMlVXHvkn1oTtZOPD0PZIRTgEwSr12pfAwzvfzwy5EU0vECRMTkDoM3gfb8fYPq00xe19tt8h";

    init();
    stripeComponent(publicKey);
}

main();
