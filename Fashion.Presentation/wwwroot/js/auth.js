import { postApiAsync, getApiAsync } from "./helper.js";
import { setLocalStorage } from "./helper.js";
import Constant from "./constant.js";

async function login(e, form) {
    e.preventDefault();

    const uri = `${Constant.UrlApi}api/account/login`;
    const email = form.querySelector("#email").value.trim();
    const password = form.querySelector("#password").value.trim();
    const authMessage = document.getElementById("authMessage");

    // Clear previous messages
    authMessage.innerHTML = "";

    try {
        const response = await postApiAsync(uri, { email, password });
        console.log(response);

        if (!response.status) {
            authMessage.innerHTML =
                '<div class="alert alert-danger">Email or Password is not correct.</div>';
            return;
        }

        setLocalStorage(Constant.Token, response.data.token);
        setLocalStorage(Constant.IsAdmin, response.data.isAdmin);

        await createCart();
        window.location.href = Constant.Url;
    } catch (error) {
        console.error("An error occurred during login:", error);
        authMessage.innerHTML =
            '<div class="alert alert-danger">An unexpected error occurred. Please try again later.</div>';
    }
}

async function createCart() {
    const uri = `${Constant.UrlApi}api/cart`;
    try {
        const response = await postApiAsync(uri);
        console.log(response);

        if (!response.status) {
            return;
        }
    } catch (error) {
        console.error("An error occurred during login:", error);
    }
}

async function register(e, form) {
    e.preventDefault();

    const uri = `${Constant.UrlApi}api/account/register`;
    const fullName = form.querySelector("#fullName").value.trim();
    const email = form.querySelector("#email").value.trim();
    const password = form.querySelector("#password").value.trim();
    const confirmPassword = form.querySelector("#confirmPassword").value.trim();
    const authMessage = document.getElementById("authMessage");

    // Clear previous messages
    authMessage.innerHTML = "";

    // Input validation
    if (password.length < 6) {
        authMessage.innerHTML =
            '<div class="alert alert-warning">Password must be at least 6 characters long.</div>';
        return;
    }

    if (password !== confirmPassword) {
        authMessage.innerHTML =
            '<div class="alert alert-warning">Passwords do not match.</div>';
        return;
    }

    try {
        const response = await postApiAsync(uri, { email, password, fullName });
        console.log(response);

        if (!response.status) {
            authMessage.innerHTML = `<div class="alert alert-danger">${response.message}</div>`;
            return;
        }

        window.location.href = `${Constant.Url}account/login`;
    } catch (error) {
        console.error("An error occurred during registration:", error);
        authMessage.innerHTML =
            '<div class="alert alert-danger">An unexpected error occurred. Please try again later.</div>';
    }
}

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
    const myOrder = document.getElementById("my-order");
    const url = `${Constant.UrlApi}api/order/my-order`;
    try {
        const response = await getApiAsync(url);
        console.log(response);

        if (!response.status) {
            return;
        }

        const data = response.data;

        myOrder.innerHTML = data
            .map((d) => {
                return `
                <tr>
                    <th scope="col">${d.id}</th>
                    <td>$${d.total.toFixed(2)}</td>
                    <td>Visa</td>
                    <td><span class="dot dot-lg bg-warning mr-2"></span>${
                        d.status
                    }</td>
                </tr>`;
            })
            .join("");
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

function auth(route) {
    const registerForm = document.getElementById("register-form");
    const loginForm = document.getElementById("login-form");

    switch (route) {
        case "login":
            loginForm.onsubmit = async (e) => await login(e, loginForm);
            break;
        case "register":
            registerForm.onsubmit = async (e) =>
                await register(e, registerForm);
            break;
        default:
            getUserInfo();
            getMyOrder();
            break;
    }
}

export default auth;
