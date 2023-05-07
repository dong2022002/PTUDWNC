import axios from "axios";
import { ApiUrl, delete_api, get_api, post_api, put_api } from "./Method";
export async function getAllCategories() {
  try {
    const respone = await axios.get(ApiUrl + `/api/categories`);
    const data = respone.data;
    if (data.isSuccess) {
      return data.result;
    } else return null;
  } catch (error) {
    console.log("Error", error.message);
    return null;
  }
}

export async function getRandomCategories(limit) {
  try {
    const respone = await axios.get(
      ApiUrl + `/api/categories/randomCategories/${limit}`
    );
    const data = respone.data;
    if (data.isSuccess) {
      return data.result;
    } else return null;
  } catch (error) {
    console.log("Error", error.message);
    return null;
  }
}

export async function getCategories(
  keyword = "",
  pageSize = 10,
  pageNumber = 1,
  sortColumn = "",
  sortOrder = "desc"
) {
  let url = new URL(ApiUrl + `/api/categories/PagedCategories`);
  keyword !== "" && url.searchParams.append("Keyword", keyword);
  sortColumn !== "" && url.searchParams.append("SortColumn", sortColumn);
  sortOrder !== "" && url.searchParams.append("SortOrder", sortOrder);
  url.searchParams.append("PageSize", pageSize);
  url.searchParams.append("PageNumber", pageNumber);
  return get_api(url.href);
}

export async function addOrUpdateCategory(formData, id) {
  if (id > 0) {
    return await put_api(ApiUrl + `/api/categories`, formData);
  } else {
    return await post_api(ApiUrl + `/api/categories`, formData);
  }
}

export async function deleteCategory(id) {
  return await delete_api(ApiUrl + `/api/categories/${id}`);
}

export async function getCategoryBySlug(slug) {
  return get_api(ApiUrl + `/api/categories/${slug}`);
}
