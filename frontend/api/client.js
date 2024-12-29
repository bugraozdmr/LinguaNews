import { create } from "apisauce";

const api = create({
  // todo try localhost instead
  baseURL: "http://192.168.1.64:6009",
  //baseURL: "http://localhost",
});

export default api;
