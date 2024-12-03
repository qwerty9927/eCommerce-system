import Constant from "./constant.js";
import {
    postApiAsync,
    getApiAsync,
    putApiAsync,
    analyzeUrl,
} from "./helper.js";

async function search(e, pageSize, pageIndex) {
    // const productSpace = document.getElementById("product-space");
    // const pagination = document.getElementById("pagination");
    const searchValue = document.getElementById("search-input").value;

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

        products = response.data.records;
        maxIndex = Math.ceil(response.data.totalRecord / pageSize);

        render(response.data.records, response.data.totalRecord, pageIndex);

        // productSpace.innerHTML = response.data.records
        //     .map((product) => {
        //         return `
        //             <div class="col-sm-6 col-lg-4 mb-4" data-aos="fade-up">
        //                 <div class="block-4 text-center border">
        //                     <figure class="block-4-image">
        //                     <a href="shop-single.html"><img src="images/cloth_1.jpg" alt="Image placeholder" class="img-fluid"></a>
        //                     </figure>
        //                     <div class="block-4-text p-4">
        //                         <h3><a href="shop-single.html">${
        //                             product.productName
        //                         }</a></h3>
        //                         <p class="mb-0"></p>
        //                         <p class="text-primary font-weight-bold">$${
        //                             product?.sizes?.[0]?.price ?? 0.0
        //                         }</p>
        //                     </div>
        //                 </div>
        //             </div>
        //         `;
        //     })
        //     .join("");

        // pagination.innerHTML = new Array(
        //     Math.ceil(response.data.totalRecord / 10)
        // )
        //     .fill(null)
        //     .map((item, index) => {
        //         return `<li class="${
        //             index == pageIndex ? "active" : ""
        //         }"><span>${index + 1}</span></li>`;
        //     })
        //     .join("");

        // paging();
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

function render(data, totalRecord, pageIndex) {
    const productSpace = document.getElementById("product-space");
    const pagination = document.getElementById("pagination");

    productSpace.innerHTML = data
        .map((product) => {
            console.log(data);
            return `
                    <div class="col-sm-6 col-lg-4 mb-4" data-aos="fade-up">
                        <div class="block-4 text-center border">
                            <figure class="block-4-image">
                            <a href="shop/${
                                product.id
                            }"><img src="images/cloth_1.jpg" alt="Image placeholder" class="img-fluid"></a>
                            </figure>
                            <div class="block-4-text p-4">
                                <h3><a href="shop/${product.id}">
                                    ${product.productName}</a></h3>
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

    pagination.innerHTML = new Array(Math.ceil(totalRecord / 10))
        .fill(null)
        .map((item, index) => {
            return `<li class="${index == pageIndex ? "active" : ""}"><span>${
                index + 1
            }</span></li>`;
        })
        .join("");

    paging();
}

function paging() {
    const pagination = document.getElementById("pagination");
    const paginationItems = pagination.querySelectorAll("li");

    // Attach click event to each pagination item
    paginationItems.forEach((item) => {
        item.addEventListener("click", async (e) => {
            // Remove the 'active' class from all list items
            paginationItems.forEach((i) => {
                i.classList.remove("active");
            });

            await search(e, 10, Number(item.textContent) - 1);

            // Add the 'active' class to the clicked list item
            item.classList.add("active");
        });
    });
}

function filter(listSizeName) {
    return products
        .map((p) => {
            if (
                listSizeName.every((n) => p.sizes.some((s) => s.sizeName === n))
            ) {
                return p;
            }

            return null;
        })
        .filter((e) => e != null);
}

function getElementsByCategoryPrefix() {
    const allElements = document.querySelectorAll("*"); // Select all elements
    const regex = /^category-/; // Regex pattern to match 'id' starting with 'category-'
    const matchingElements = [];

    allElements.forEach((el) => {
        if (regex.test(el.id)) {
            // Test if the id matches the pattern
            matchingElements.push(el);
        }
    });

    return matchingElements;
}

function getCategory() {
    const categories = getElementsByCategoryPrefix();

    categories.forEach((c) => {
        c.onclick = async (e) => {
            const url = `${Constant.UrlApi}api/category/${c.getAttribute(
                "data"
            )}`;
            console.log(url);

            try {
                const response = await getApiAsync(url);
                console.log(response.data.products);

                if (!response.status) {
                    return;
                }

                render(
                    response.data.products,
                    response.data.products.length,
                    0
                );
            } catch (error) {
                console.error("An error occurred:", error);
            }
        };
    });
}

async function addToCart(id) {
    const sizeSelectedId = document
        .querySelector('input[name="shop-sizes"]:checked')
        .getAttribute("data");
    const quantity = Number(document.getElementById("item-quantity").value);

    console.log(quantity);
    const url = `${Constant.UrlApi}api/cart/add`;
    try {
        const response = await putApiAsync(url, {
            productId: id,
            quantity,
            sizeId: sizeSelectedId,
        });
        console.log(response);

        if (!response.status) {
            return;
        }

        alert("Add to cart successful");
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

let pageIndex = 0;
let products;
let maxIndex = 2;

function mainPage() {
    const searchInput = document.getElementById("search-input");
    const backPageEle = document.getElementById("back-page");
    const nextPageEle = document.getElementById("next-page");
    const pagination = document.getElementById("pagination");
    pagination.querySelector("li").classList.add("active");

    paging();
    getCategory();

    searchInput.onkeyup = async (e) => {
        if (e.key === "Enter") {
            await search(e, 10, 0); // Perform the initial search
        }
    };

    backPageEle.onclick = async (e) => {
        if (pageIndex > 0) {
            pageIndex--;
            await search(e, 10, pageIndex);
        } else {
            console.log("Already on the first page.");
        }
    };

    nextPageEle.onclick = async (e) => {
        if (pageIndex < maxIndex - 1) {
            pageIndex++;
            await search(e, 10, pageIndex);
        } else {
            console.log("Already on the last page.");
        }
    };

    // // Filter
    // const sSm = document.getElementById("s_sm");
    // const sMd = document.getElementById("s_md");
    // const sLg = document.getElementById("s_lg");

    // if(!sSm.checked )

    // filter()
}

function subPage(id) {
    // Add to cart
    const addToCartBtn = document.getElementById("add-to-cart");

    addToCartBtn.onclick = async (e) => await addToCart(id);
}

function shop() {
    const path = analyzeUrl(window.location.href);
    if (path.route1) {
        subPage(path.route1);
        return;
    }

    mainPage();
}

export default shop;
