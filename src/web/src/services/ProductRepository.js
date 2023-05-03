import axios from "axios";
import { ApiUrl } from "./Method";
export async function getFeaturedProducts(limit = 4) {
  try {
    const respone = await axios.get(ApiUrl + `/api/products/featured/${limit}`);
    const data = respone.data;
    if (data.isSuccess) {
      return data.result;
    } else return null;
  } catch (error) {
    console.log("Error", error.message);
    return null;
  }
}

export async function getNewestProducts(limit = 4) {
  try {
    const respone = await axios.get(
      ApiUrl + `/api/products/newestProduct/${limit}`
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

export async function getDiscountProduct(limit = 4) {
  try {
    const respone = await axios.get(
      ApiUrl + `/api/products/discountProduct/${limit}`
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

export async function getRandomProduct(limit) {
  try {
    const respone = await axios.get(
      ApiUrl + `/api/products/randomProduct/${limit}`
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
