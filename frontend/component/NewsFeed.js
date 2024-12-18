import React, { useState, useEffect } from "react";
import { Text, View, StyleSheet, FlatList } from "react-native";
import news from "../api/getNews";
import Card from "./Card";
import LottieView from "lottie-react-native";

const NewsFeed = ({ navigation }) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [refreshing, setRefreshing] = useState(false);
  const [page, setPage] = useState(1);
  const [hasMoreData, setHasMoreData] = useState(true);

  const getResult = async (pageNumber = 1) => {
    try {
      setLoading(true);

      const response = await news.getNews(pageNumber);
      console.log(JSON.stringify(response, null, 2));

      if (response?.data?.news?.data) {
        const newData = response.data.news.data;
        const totalItemCount = response.data.news.count;

        // Yeni verileri mevcut verilerin sonuna ekleyelim
        setData((prevData) => (pageNumber === 1 ? newData : [...prevData, ...newData]));

        // Daha fazla veri olup olmadığını kontrol edelim
        setHasMoreData(data.length + newData.length < totalItemCount);
      } else {
        console.error("API yanıtı beklenen yapıda değil:", response);
      }
    } catch (error) {
      console.error("API request failed:", error);
    } finally {
      setLoading(false);
      setRefreshing(false);
    }
  };


  useEffect(() => {
    getResult(page);
  }, [page]);

  const handleLoadMore = () => {
    if (hasMoreData && !loading) {
      setPage((prevPage) => prevPage + 1);
    }
  };

  const handleRefresh = () => {
    setRefreshing(true);
    setPage(1); // Sayfayı sıfırla
    setData([]); // Eski verileri temizle
  };

  
  return (
    <View style={styles.container}>
      {loading && page === 1 ? ( // İlk yüklemede animasyon göster
        <View style={styles.container}>
          <LottieView
            loop
            autoPlay
            source={require("../animations/96231-loading-orange-animation.json")}
          />
        </View>
      ) : (
        <View>
          <Text style={styles.text}>Recently Added News</Text>
          <FlatList
            data={data}
            keyExtractor={(item) => item.slug} // Benzersiz anahtar olarak slug kullan
            renderItem={({ item }) => (
              <Card
                title={item.title}
                categoryName={item.category.name}
                createdAt={item.createdAt}
                image={item.image}
                onPress={() => navigation.navigate("Info", item)}
              />
            )}
            onEndReached={handleLoadMore} // Sayfa sonuna geldiğinde
            onEndReachedThreshold={0.5} // Yükleme başlama eşiği
            refreshing={refreshing}
            onRefresh={handleRefresh} // Listeyi yenile
          />
        </View>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    paddingTop: 50,
    flex: 1,
    backgroundColor: "#ffcccc",
    padding: 10,
    paddingBottom: 50,
  },
  text: {
    fontSize: 20,
    textAlign: "center",
    color: "#fc5c65",
    marginBottom: 15,
    fontWeight: "bold",
  },
});
export default NewsFeed;
