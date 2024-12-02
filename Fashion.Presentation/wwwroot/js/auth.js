import { postApiAsync } from "./helper.js";
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
        window.location.href = Constant.Url;
    } catch (error) {
        console.error("An error occurred during login:", error);
        authMessage.innerHTML =
            '<div class="alert alert-danger">An unexpected error occurred. Please try again later.</div>';
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
    }
}

export default auth;
