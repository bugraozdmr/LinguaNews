import api from "./client";

const getNews = async () => {
  try {
    const response = await api.get("/news");

    if (response.status === 200 && response.data && response.data.news) {
      return response;
    } else {
      console.log("No news found");
    }
  } catch (error) {
    console.error("API request failed:", error);
  }
};

const searchedNews = (query) => {
  return api.get(`/news?query=${query}`);
};

export default {
  getNews,
  searchedNews,
};
