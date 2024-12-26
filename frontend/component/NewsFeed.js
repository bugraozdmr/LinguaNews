import React, { useState, useEffect } from "react";
import { Text, View, StyleSheet, FlatList } from "react-native";
import news from "../api/getNews";
import Card from "./Card";
import LottieView from "lottie-react-native";

const NewsFeed = ({ navigation }) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [refresh, onRefresh] = useState(false);
  const [pageIndex, setPageIndex] = useState(0); // Başlangıç sayfa indeksi
  const [pageSize] = useState(1); // Sayfa başına haber sayısı
  const [totalPages, setTotalPages] = useState(1); // Toplam sayfa sayısı

  const getResult = async (page = 0) => {
    try {
      setLoading(true);

      const response = await news.getNews({ pageIndex: page, pageSize });

      if (!response || !response.ok || !response.data) {
        console.log("ERROR: API çağrısı başarısız oldu");
        setLoading(false);
        return;
      }

      const fetchedData = response.data.news.data; // Gelen haber verisi
      const totalPagesFromApi = response.data.news.totalPages; // Toplam sayfa sayısı

      setData((prevData) => (page === 0 ? fetchedData : [...prevData, ...fetchedData]));
      setTotalPages(totalPagesFromApi);
    } catch (error) {
      console.error("API request failed:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getResult(pageIndex);
  }, [pageIndex]);

  const loadMoreData = () => {
    if (!loading && pageIndex + 1 < totalPages) {
      setPageIndex((prevPage) => prevPage + 1);
    }
  };

  return (
    <View style={styles.container}>
      {!loading ? (
        <View>
          <Text style={styles.text}>Recently Added News</Text>
          <FlatList
            onRefresh={() => {
              setPageIndex(0);
              getResult(0);
            }}
            refreshing={refresh}
            data={data}
            keyExtractor={(news) => news.publishedAt + news.title}
            renderItem={({ item }) => (
              <Card
                title={item.title}
                categoryName={item.category.name}
                createdAt={item.createdAt}
                image={item.image}
                onPress={() => navigation.navigate("Info", item)}
              />
            )}
            onEndReached={loadMoreData}
            onEndReachedThreshold={0.5} // Alt sınıra yaklaşıldığında daha fazla veri getirir
            ListFooterComponent={
              loading && <LottieView source={require("../animations/96231-loading-orange-animation.json")} autoPlay loop />
            }
          />
        </View>
      ) : (
        <View style={styles.container}>
          <LottieView
            loop
            autoPlay
            source={require("../animations/96231-loading-orange-animation.json")}
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
