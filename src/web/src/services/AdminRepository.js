import { ApiUrl, post_api } from "./Method";
export async function checkAdmin(formData) {
  return await post_api(ApiUrl + `/api/admin`, formData);
}
