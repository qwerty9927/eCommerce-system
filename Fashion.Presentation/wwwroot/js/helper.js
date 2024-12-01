import Constant from "./constant.js";

function getLocalStorage(key) {
    return localStorage.getItem(key) || "";
}

function setLocalStorage(key, value) {
    localStorage.setItem(key, value);
}

function postApi(data) {
    fetch(`${Constant.Uri}api/Order/add-card`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            // Authorization: `Bearer ${getLocalStorage(Constant.Token)}`,
            Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InRhbi52bzFAeW9wbWFpbC5jb20iLCJzdWIiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJ1c2VySWQiOiI2NTE1ZGUxYi03Y2RkLTRlZjUtOGMyNi03OWZjNWMyZWY0MGQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c2VyIiwiZXhwIjoxNzMzMDU4NzY5fQ.t78mSd7vcJOchY4UWk9dg85PEGy7fA1UyS04WgzVirw`,
        },
        body: JSON.stringify(data),
    })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            console.log("Success:", data);

            return data;
        })
        .catch((error) => {
            console.error("Error:", error);
        });
}

export { getLocalStorage, setLocalStorage, postApi };
