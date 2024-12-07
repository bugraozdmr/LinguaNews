import React, { useState, useEffect } from "react";
import { Text, View, StyleSheet, FlatList } from "react-native";
import news from "../api/getNews";
import Card from "./Card";
import LottieView from "lottie-react-native";

const NewsFeed = ({ navigation }) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [refresh, onRefresh] = useState(false);
  const getResult = async () => {
    try {
      setLoading(true);

      const response = await news.getNews();

      if (!response) {
        console.log("ERROR: Response is undefined or null");
        setLoading(false);
        return;
      }

      if (!response.ok) {
        console.log("ERROR: Response not OK", response);
        setLoading(false);
        return;
      }

      if (!response.data) {
        console.log("ERROR: No data fetched");
        setLoading(false);
        return;
      }

      setData(response.data.news.data);
    } catch (error) {
      console.error("API request failed:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getResult();
  }, []);

  useEffect(() => {
    getResult();
  }, []);
  return (
    <View style={styles.container}>
      {!loading ? (
        <View>
          <Text style={styles.text}>Recently Added News</Text>
          <FlatList
            onRefresh={() => getResult()}
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
