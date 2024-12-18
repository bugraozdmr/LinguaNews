import React, { useState, useEffect } from "react";
import {
  Text,
  View,
  StyleSheet,
  FlatList,
  TouchableOpacity,
} from "react-native";
import news from "../api/getNews";
import Card from "./Card";
import LottieView from "lottie-react-native";

const MyNews = ({ navigation }) => {
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
      {/* Üst Kısım: İki Buton */}
      <View style={styles.buttonContainer}>
        <TouchableOpacity
          style={styles.roundButton}
          onPress={() => navigation.navigate("AllNews")}
        >
          <Text style={styles.buttonText}>All News</Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.roundButton}
          onPress={() => navigation.navigate("FavoriteNews")}
        >
          <Text style={styles.buttonText}>Favorite News</Text>
        </TouchableOpacity>
      </View>
      {!loading ? (
        <View>
          <Text style={styles.text}>My News</Text>
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
  roundButton: {
    width: 150, // Butonun genişliği
    height: 60, // Butonun yüksekliği
    borderRadius: 30, // Yarı çap (width ve height'in yarısı)
    backgroundColor: "white", // Butonun arka plan rengi
    justifyContent: "center", // İçeriği dikeyde hizalar
    alignItems: "center", // İçeriği yatayda hizalar
    marginHorizontal: 10, // Butonlar arasında boşluk bırakır
  },
  buttonContainer: {
    alignItems: "center",
    backgroundColor: "#ffcccc",
    borderRadius: 5,
    marginHorizontal: 10,
    padding: 15,
    flexDirection: "row",
    justifyContent: "space-between",
  },
});
export default MyNews;
