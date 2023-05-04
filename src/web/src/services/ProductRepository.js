import { ApiUrl, get_api } from "./Method";
export async function getFeaturedProducts(limit = 4) {
  return get_api(ApiUrl + `/api/products/featured/${limit}`);
}

export async function getNewestProducts(limit = 4) {
  return get_api(ApiUrl + `/api/products/newestProduct/${limit}`);
}

export async function getDiscountProduct(limit = 4) {
  return get_api(ApiUrl + `/api/products/discountProduct/${limit}`);
}

export async function getRandomProduct(limit) {
  return get_api(ApiUrl + `/api/products/randomProduct/${limit}`);
}

export async function getProductById(id) {
  return get_api(ApiUrl + `/api/products/${id}`);
}

export async function getProductsFilter(
  keyword = "",
  categorySlug = "",
  pageSize = 10,
  pageNumber = 1,
  sortColumn = "",
  sortOrder = "desc"
) {
  let url = new URL(ApiUrl + `/api/products`);
  keyword !== "" && url.searchParams.append("Keyword", keyword);
  categorySlug !== "" && url.searchParams.append("CategorySlug", categorySlug);
  sortColumn !== "" && url.searchParams.append("SortColumn", sortColumn);
  sortOrder !== "" && url.searchParams.append("SortOrder", sortOrder);
  url.searchParams.append("PageSize", pageSize);
  url.searchParams.append("PageNumber", pageNumber);
  console.log(url.href);
  return get_api(url.href);
}
