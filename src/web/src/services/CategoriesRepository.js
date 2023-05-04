import axios from "axios";
import { ApiUrl } from "./Method";
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
