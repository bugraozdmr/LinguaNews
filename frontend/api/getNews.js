import api from "./client";

const getNews = async ({ pageIndex = 0, pageSize = 10 }) => {
  try {
    const response = await api.get(`/news`, {
      params: {
        pageIndex,
        pageSize,
      },
    });

    return response; // API yanıtını doğrudan döndürüyoruz
  } catch (error) {
    console.error("getNews API çağrısı başarısız oldu:", error);
    return { ok: false, data: null }; // Hata durumunda standart bir yanıt döndür
  }
};

const searchedNews = (query) => {
  return api.get(`/news?query=${query}`);
};

export default {
  getNews,
  searchedNews,
};
