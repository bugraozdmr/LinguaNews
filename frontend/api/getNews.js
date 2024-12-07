import api from "./client";

const apiKey = "3ae5a5ef96654c5990a306756cc00cc5"
const getNews = () => {
  return api.get(
    "https://newsapi.org/v2/top-headlines?country=tr&apiKey=${apikey}"
  );
};
const searchedNews = (str) => {
  return api.get(`everything?q=${str}&apiKey=${apikey}`);
};
export default {
  getNews,
  searchedNews,
};
