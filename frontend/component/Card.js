import React from "react";
import {
  View,
  StyleSheet,
  Image,
  Text,
  TouchableWithoutFeedback,
} from "react-native";
import AppButton from "./AppButton";

const Card = ({ title, categoryName, image, createdAt, onPress }) => {
  return (
    <TouchableWithoutFeedback onPress={onPress}>
      <View style={styles.container}>
        <Image
          style={styles.image}
          source={
            image
              ? {
                  uri: image,
                }
              : require("../assets/download.png")
          }
        />
        <View style={styles.detailsConatiner}>
          <Text style={styles.title}>{title}</Text>
          <Text style={styles.categoryName}>{categoryName}</Text>
          <Text style={styles.createdAt}>
            {new Date(createdAt).toLocaleString("en-GB", {
              day: "numeric",
              month: "long",
              year: "numeric",
              hour: "2-digit",
              minute: "2-digit",
            })}
          </Text>
        </View>
        <AppButton onPress={onPress} title="Full News Link" />
      </View>
    </TouchableWithoutFeedback>
  );
};
const styles = StyleSheet.create({
  container: {
    backgroundColor: "white",
    borderRadius: 25,
    overflow: "hidden",
    marginBottom: 20,
  },
  image: {
    width: "100%",
    height: 200,
  },
  detailsConatiner: {
    padding: 20,
  },
  categoryName: {
    fontSize: 15,
    marginTop: 5,
  },
  createdAt: {
    fontSize: 12,
    marginTop: 15,
  },
  title: {
    fontSize: 18,
    color: "#FF595A",
    marginBottom: 7,
    fontWeight: "bold",
  },
});
export default Card;
