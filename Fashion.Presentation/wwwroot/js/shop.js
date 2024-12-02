import Constant from "./constant.js";
import { postApiAsync } from "./helper.js";

async function search(e, searchValue, pageSize, pageIndex) {
    const productSpace = document.getElementById("product-space");
    const pagination = document.getElementById("pagination");

    if (e.key === "Enter") {
        const url = `${Constant.UrlApi}api/product/search`;
        try {
            const response = await postApiAsync(url, {
                keyWord: searchValue,
                pageIndex,
                pageSize,
            });
            console.log(response);

            if (!response.status) {
                return;
            }

            productSpace.innerHTML = response.data.records
                .map((product) => {
                    return `
                    <div class="col-sm-6 col-lg-4 mb-4" data-aos="fade-up">
                        <div class="block-4 text-center border">
                            <figure class="block-4-image">
                            <a href="shop-single.html"><img src="images/cloth_1.jpg" alt="Image placeholder" class="img-fluid"></a>
                            </figure>
                            <div class="block-4-text p-4">
                                <h3><a href="shop-single.html">${
                                    product.productName
                                }</a></h3>
                                <p class="mb-0"></p>
                                <p class="text-primary font-weight-bold">$${
                                    product?.sizes?.[0]?.price ?? 0.0
                                }</p>
                            </div>
                        </div>
                    </div>
                `;
                })
                .join("");

            pagination.innerHTML = new Array(
                Math.ceil(response.data.totalRecord / 10)
            )
                .fill(null)
                .map((item, index) => {
                    return `<li class="active"><span>${index + 1}</span></li>`;
                })
                .join("");
        } catch (error) {
            console.error("An error occurred:", error);
        }
    }
}

async function nextPage(e, searchValue, pageSize, pageIndex) {
    const productSpace = document.getElementById("product-space");
    const pagination = document.getElementById("pagination");

    const url = `${Constant.UrlApi}api/product/search`;
    try {
        const response = await postApiAsync(url, {
            keyWord: searchValue,
            pageIndex,
            pageSize,
        });
        console.log(response);

        if (!response.status) {
            return;
        }

        productSpace.innerHTML = response.data.records
            .map((product) => {
                return `
                    <div class="col-sm-6 col-lg-4 mb-4" data-aos="fade-up">
                        <div class="block-4 text-center border">
                            <figure class="block-4-image">
                            <a href="shop-single.html"><img src="images/cloth_1.jpg" alt="Image placeholder" class="img-fluid"></a>
                            </figure>
                            <div class="block-4-text p-4">
                                <h3><a href="shop-single.html">${
                                    product.productName
                                }</a></h3>
                                <p class="mb-0"></p>
                                <p class="text-primary font-weight-bold">$${
                                    product?.sizes?.[0]?.price ?? 0.0
                                }</p>
                            </div>
                        </div>
                    </div>
                `;
            })
            .join("");

        pagination.innerHTML = new Array(
            Math.ceil(response.data.totalRecord / 10)
        )
            .fill(null)
            .map((item, index) => {
                return `<li class="active"><span>${index + 1}</span></li>`;
            })
            .join("");
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

async function backPage(e, searchValue, pageSize, pageIndex) {
    const productSpace = document.getElementById("product-space");
    const pagination = document.getElementById("pagination");

    const url = `${Constant.UrlApi}api/product/search`;
    try {
        const response = await postApiAsync(url, {
            keyWord: searchValue,
            pageIndex,
            pageSize,
        });
        console.log(response);

        if (!response.status) {
            return;
        }

        productSpace.innerHTML = response.data.records
            .map((product) => {
                return `
                    <div class="col-sm-6 col-lg-4 mb-4" data-aos="fade-up">
                        <div class="block-4 text-center border">
                            <figure class="block-4-image">
                            <a href="shop-single.html"><img src="images/cloth_1.jpg" alt="Image placeholder" class="img-fluid"></a>
                            </figure>
                            <div class="block-4-text p-4">
                                <h3><a href="shop-single.html">${
                                    product.productName
                                }</a></h3>
                                <p class="mb-0"></p>
                                <p class="text-primary font-weight-bold">$${
                                    product?.sizes?.[0]?.price ?? 0.0
                                }</p>
                            </div>
                        </div>
                    </div>
                `;
            })
            .join("");

        pagination.innerHTML = new Array(
            Math.ceil(response.data.totalRecord / 10)
        )
            .fill(null)
            .map((item, index) => {
                return `<li class="active"><span>${index + 1}</span></li>`;
            })
            .join("");
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

let pageIndex = 1;

function shop() {
    const searchInput = document.getElementById("search-input");
    const backPageEle = document.getElementById("back-page");
    const nextPageEle = document.getElementById("next-page");

    const searchValue = searchInput.value;

    searchInput.onkeyup = (e) => search(e, searchValue, 9999, 0);
    backPageEle.onclick = (e) => backPage(e, searchValue, 10, ++pageIndex);
    nextPageEle.onclick = (e) => nextPage(e, searchValue, 10, --pageIndex);
}

export default shop;
