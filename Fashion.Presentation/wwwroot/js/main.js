import auth from "./auth.js";
import cart from "./cart.js";
import checkout from "./checkout.js";
import Constant from "./constant.js";
import dashboard from "./dashboard.js";
import { analyzeUrl, getLocalStorage, setLocalStorage } from "./helper.js";
import init from "./init.js";
import shop from "./shop.js";

function main() {
    init();
    sideEffect();

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

        case "dashboard":
            if (JSON.parse(getLocalStorage(Constant.IsAdmin))) {
                dashboard(routeDeserialize.route1);
            } else {
                window.location.href = "/";
            }
            break;
    }
}

function sideEffect() {
    const loginLogout = document.getElementById("login-logout");
    const myProfile = document.getElementById("my-profile");
    let isLogin = false;

    if (getLocalStorage(Constant.Token)) {
        isLogin = true;
        loginLogout.href = "#";
        loginLogout.textContent = "Logout";
    } else {
        loginLogout.href = "/account/login";
        loginLogout.textContent = "Login";
    }

    loginLogout.onclick = (e) => {
        if (e.target.textContent == "Logout") {
            e.preventDefault();

            isLogin = false;
            loginLogout.href = "/account/login";
            loginLogout.textContent = "Login";
            setLocalStorage(Constant.Token, "");
            setLocalStorage(Constant.IsAdmin, false);

            window.location.href = "/";
        }
    };

    if (!isLogin) {
        myProfile.style.display = "none";
    } else {
        if (JSON.parse(getLocalStorage(Constant.IsAdmin))) {
            myProfile.href = "/dashboard";
        }
    }
}

main();
