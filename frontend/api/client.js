import { create } from "apisauce";

const api = create({
  // todo try localhost instead
  baseURL: "http://192.168.1.70:6009",
});

export default api;
