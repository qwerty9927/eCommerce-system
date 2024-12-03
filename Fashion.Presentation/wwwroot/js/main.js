import auth from "./auth.js";
import cart from "./cart.js";
import checkout from "./checkout.js";
import { analyzeUrl } from "./helper.js";
import init from "./init.js";
import shop from "./shop.js";

function main() {
    init();

    const routeDeserialize = analyzeUrl(window.location.href);

    console.log(routeDeserialize);

    switch (routeDeserialize.route0) {
        case "account":
            auth(routeDeserialize.route1);
            break;

        case "checkout":
            checkout();
            break;

        case "shop":
            shop();
            break;

        case "cart":
            cart();
            break;
    }
}

main();
