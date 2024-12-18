import { create } from "apisauce";

const api = create({
  // todo try localhost instead
  baseURL: "http://192.168.60.158:6009",
});

export default api;
