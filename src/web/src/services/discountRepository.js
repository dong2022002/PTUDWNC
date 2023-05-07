import { ApiUrl, delete_api, get_api, post_api, put_api } from "./Method";

export async function getDiscounts(
  keyword = "",
  pageSize = 10,
  pageNumber = 1,
  sortColumn = "",
  sortOrder = "desc"
) {
  let url = new URL(ApiUrl + `/api/discount`);
  keyword !== "" && url.searchParams.append("Keyword", keyword);
  sortColumn !== "" && url.searchParams.append("SortColumn", sortColumn);
  sortOrder !== "" && url.searchParams.append("SortOrder", sortOrder);
  url.searchParams.append("PageSize", pageSize);
  url.searchParams.append("PageNumber", pageNumber);
  return get_api(url.href);
}

export async function addOrUpdateDiscount(formData, id) {
  if (id > 0) {
    return await put_api(ApiUrl + `/api/discount`, formData);
  } else {
    return await post_api(ApiUrl + `/api/discount`, formData);
  }
}

export async function deleteDiscount(id) {
  return await delete_api(ApiUrl + `/api/discount/${id}`);
}
