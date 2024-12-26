import React, { useState, useEffect } from "react";
import { View, Text, StyleSheet, FlatList, Image } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

const UnreadNews = () => {
  const [savedNews, setSavedNews] = useState([]);
  const [refreshing, setRefreshing] = useState(false);

  // Kaydedilen haberleri AsyncStorage'den al
  const getSavedNews = async () => {
    try {
      const storedNews = await AsyncStorage.getItem("readNews");
      const newsList = storedNews ? JSON.parse(storedNews) : [];
      setSavedNews(newsList); // Listeyi güncelle
    } catch (error) {
      console.error("Kaydedilen haberler alınırken hata oluştu:", error);
    }
  };

  // Sayfayı yenileme işlemi
  const onRefresh = async () => {
    setRefreshing(true);
    await getSavedNews(); // Haberleri yeniden al
    setRefreshing(false); // Yenileme durumu sonlandır
  };

  useEffect(() => {
    getSavedNews();
  }, []);

  return (
    <View style={styles.container}>
      <FlatList
        data={savedNews}
        keyExtractor={(item) => item.title}
        renderItem={({ item }) => (
          <View style={styles.newsItem}>
            <Image source={{ uri: item.image }} style={styles.newsImage} />
            <Text style={styles.newsTitle}>{item.title}</Text>
            <Text style={styles.newsDate}>
              {new Date(item.createdAt).toLocaleString("en-GB", {
                day: "numeric",
                month: "long",
                year: "numeric",
              })}
            </Text>
          </View>
        )}
        // Pull to Refresh işlevselliği
        refreshing={refreshing}
        onRefresh={onRefresh}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  newsItem: {
    padding: 15,
    marginBottom: 10,
    borderRadius: 10,
    backgroundColor: "#f4f4f4",
    shadowColor: "#000",
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.8,
    shadowRadius: 2,
    elevation: 5,
  },
  newsImage: {
    width: "100%",
    height: 200,
    borderRadius: 10,
  },
  newsTitle: {
    fontSize: 18,
    fontWeight: "bold",
    color: "#333",
  },
  newsDate: {
    fontSize: 12,
    color: "#888",
  },
});

export default UnreadNews;
