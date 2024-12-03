import Constant from "./constant.js";

function getLocalStorage(key) {
    return localStorage.getItem(key) || "";
}

function setLocalStorage(key, value) {
    localStorage.setItem(key, value);
}

async function postApiAsync(uri, data) {
    const response = await fetch(uri, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${getLocalStorage(Constant.Token)}`,
            // Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InRhbi52bzFAeW9wbWFpbC5jb20iLCJzdWIiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJ1c2VySWQiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c2VyIiwiZXhwIjoxNzMzMDU4NzY5fQ.t78mSd7vcJOchY4UWk9dg85PEGy7fA1UyS04WgzVirw`,
        },
        body: JSON.stringify(data),
    });

    const parser = await response.json();

    return parser;
}

async function putApiAsync(uri, data) {
    const response = await fetch(uri, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${getLocalStorage(Constant.Token)}`,
            // Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InRhbi52bzFAeW9wbWFpbC5jb20iLCJzdWIiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJ1c2VySWQiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c2VyIiwiZXhwIjoxNzMzMDU4NzY5fQ.t78mSd7vcJOchY4UWk9dg85PEGy7fA1UyS04WgzVirw`,
        },
        body: JSON.stringify(data),
    });

    const parser = await response.json();

    return parser;
}

async function getApiAsync(uri) {
    const response = await fetch(uri, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${getLocalStorage(Constant.Token)}`,
            // Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InRhbi52bzFAeW9wbWFpbC5jb20iLCJzdWIiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJ1c2VySWQiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c2VyIiwiZXhwIjoxNzMzMDU4NzY5fQ.t78mSd7vcJOchY4UWk9dg85PEGy7fA1UyS04WgzVirw`,
        },
    });

    const parser = await response.json();

    return parser;
}

function analyzeUrl(uri) {
    const parsedUrl = new URL(uri);

    const route = parsedUrl.pathname.toLowerCase().split("/");
    const route0 = route[1];
    const route1 = route[2];
    const queryParams = parsedUrl.search;

    return {
        route,
        route0,
        route1,
        queryParams,
    };
}

function validateEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

export {
    getLocalStorage,
    setLocalStorage,
    postApiAsync,
    analyzeUrl,
    validateEmail,
    getApiAsync,
    putApiAsync,
};
