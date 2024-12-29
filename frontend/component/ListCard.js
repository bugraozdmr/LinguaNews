import React from "react";
import { View, StyleSheet, Image, Text, TouchableWithoutFeedback } from "react-native";

const ListCard = ({ title, categoryName, image, createdAt, onPress }) => {
  return (
    <TouchableWithoutFeedback onPress={onPress}>
      <View style={styles.container}>
        <Image
          style={styles.image}
          source={image ? { uri: image } : require("../assets/download.png")}
        />
        <View style={styles.detailsContainer}>
          <Text style={styles.title}>{title}</Text>
          <Text style={styles.categoryName}>{categoryName}</Text>
          <Text style={styles.createdAt}>
            {new Date(createdAt).toLocaleString("en-GB", {
              day: "numeric",
              month: "long",
              year: "numeric",
            })}
          </Text>
        </View>
      </View>
    </TouchableWithoutFeedback>
  );
};

const styles = StyleSheet.create({
  container: {
    backgroundColor: "white",
    borderRadius: 15,
    overflow: "hidden",
    marginBottom: 15,
    flexDirection: "row",
    padding: 10,
    shadowColor: "#000",
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.3,
    shadowRadius: 4,
    elevation: 3,
  },
  image: {
    width: 80,
    height: 80,
    borderRadius: 10,
    marginRight: 10,
  },
  detailsContainer: {
    flex: 1,
    justifyContent: "center",
  },
  title: {
    fontSize: 16,
    color: "#FF595A",
    fontWeight: "bold",
    marginBottom: 5,
  },
  categoryName: {
    fontSize: 12,
    color: "#888",
  },
  createdAt: {
    fontSize: 10,
    color: "#888",
    marginTop: 5,
  },
});

export default ListCard;
