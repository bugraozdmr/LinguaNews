import React, { useState, useEffect } from "react";
import { View, FlatList, StyleSheet, Text } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import ListCard from "./ListCard"; // Card component import

const SavedNewsList = () => {
  const [savedNews, setSavedNews] = useState([]);
  const [refreshing, setRefreshing] = useState(false);

  // Retrieve saved news from AsyncStorage
  const getSavedNews = async () => {
    try {
      const storedNews = await AsyncStorage.getItem("readNews"); // Use "readNews" instead of "savedNews"
      const newsList = storedNews ? JSON.parse(storedNews) : [];
      setSavedNews(newsList); // Update the list
    } catch (error) {
      console.error("Error retrieving News Archive:", error);
    }
  };

  // Refresh the page
  const onRefresh = async () => {
    setRefreshing(true);
    await getSavedNews(); // Fetch the news again
    setRefreshing(false); // End the refreshing state
  };

  useEffect(() => {
    getSavedNews();
  }, []);

  return (
    <View style={styles.container}>
      {/* Title */}
      <Text style={styles.header}>News Archive</Text>

      <FlatList
        data={savedNews}
        keyExtractor={(item) => item.title}
        renderItem={({ item }) => (
          <ListCard
            title={item.title}
            categoryName={item.categoryName}
            image={item.image}
            createdAt={item.createdAt}
            onPress={() => {}}
          />
        )}
        // Pull to Refresh functionality
        refreshing={refreshing}
        onRefresh={onRefresh}
      />
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
  header: {
    fontSize: 24,
    fontWeight: "bold",
    color: "#FF595A", // Title color
    marginBottom: 20,
    textAlign: "center", // Centered title
  },
});

export default SavedNewsList;
