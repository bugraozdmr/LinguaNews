import React, { useState } from "react";
import { View, StyleSheet, StatusBar, FlatList, Text } from "react-native";
import AppInput from "./AppInput";
import news from "../api/getNews";
import Card from "./Card";
import LottieView from "lottie-react-native";
import NoItemFound from "./NoItemFound";

const SearchNews = ({ navigation }) => {
  const [text, setText] = useState("");
  const [data, setData] = useState([]);
  const [refreshing, onRefreshing] = useState(false);
  const [loading, setLoading] = useState(false);
  const [dataLength, setDataLength] = useState(1);
  const getNews = async () => {
    setLoading(true);

    const response = await news.searchedNews(text);

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

    const { data } = await news.searchedNews(text);
    setData(response.data.news.data);
    setDataLength(data.count);
    setLoading(false);
  };
  const handleFetch = () => {
    getNews();
  };
  const displayNews = () => {
    if (dataLength === 0) return <NoItemFound />;
    else
      return (
        <FlatList
          data={data}
          refreshing={refreshing}
          onRefreshing={() => getNews()}
          keyExtractor={(news) => news.title}
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
      );
  };
  return (
    <View style={styles.container}>
      {loading ? (
        <LottieView
          loop
          autoPlay
          source={require("../animations/96231-loading-orange-animation.json")}
        />
      ) : (
        <>
          <AppInput
            icon={"magnify"}
            serach={"arrow-right-bold-circle-outline"}
            onChangeText={(text) => setText(text)}
            placeholder="Search"
            onSearch={handleFetch}
            inputMode="text"
          />
          {displayNews()}
        </>
      )}
    </View>
  );
};
const styles = StyleSheet.create({
  container: {
    paddingTop: StatusBar.currentHeight,
    backgroundColor: "#ffcccc",
    padding: 10,
    flex: 1,
  },
});
export default SearchNews;
