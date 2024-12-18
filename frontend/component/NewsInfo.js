import React, { useState } from "react";
import {
  Image,
  Linking,
  ScrollView,
  StyleSheet,
  Text,
  View,
  Button,
  TouchableOpacity,
} from "react-native";
import Checkbox from "expo-checkbox";
import AppButton from "./AppButton";
import Icon from "./Icon";

const ListingDetails = ({ route }) => {
  const [level, setLevel] = useState("beginner");

  const getLevelText = () => {
    switch (level) {
      case "beginner":
        return route.params.beginner;
      case "intermediate":
        return route.params.intermediate;
      case "advanced":
        return route.params.advanced;
      default:
        return route.params.beginner;
    }
  };

  return (
    <View style={styles.container}>
      <ScrollView>
        <Image style={styles.image} source={{ uri: route.params.image }} />
        <View style={styles.detailsContainer}>
          <Text style={styles.title}>{route.params.title}</Text>
          <Text style={styles.createdAt}>
            Created at{" "}
            {new Date(route.params.createdAt).toLocaleString("en-GB", {
              day: "numeric",
              month: "long",
              year: "numeric",
              hour: "2-digit",
              minute: "2-digit",
            })}
          </Text>

          <Text style={styles.subtitle}>{getLevelText()}</Text>

          {/* <View style={styles.buttonContainer}>
            <Button
              style={styles.button}
              title="Beginner"
              onPress={() => setLevel("beginner")}
            />
            <Button
              style={styles.button}
              title="Intermediate"
              onPress={() => setLevel("intermediate")}
            />
            <Button
              style={styles.button}
              title="Advanced"
              onPress={() => setLevel("advanced")}
            />
          </View> */}
          <View style={styles.buttonContainer}>
            <TouchableOpacity
              style={styles.button}
              onPress={() => setLevel("beginner")}
            >
              <Text style={styles.buttonText}>Beginner</Text>
            </TouchableOpacity>

            <TouchableOpacity
              style={styles.button}
              onPress={() => setLevel("intermediate")}
            >
              <Text style={styles.buttonText}>Intermediate</Text>
            </TouchableOpacity>

            <TouchableOpacity
              style={styles.button}
              onPress={() => setLevel("advanced")}
            >
              <Text style={styles.buttonText}>Advanced</Text>
            </TouchableOpacity>
          </View>
          <View style={styles.section}>
            <Checkbox
              style={styles.checkbox}
              value={isChecked}
              onValueChange={setChecked}
            />
            <Text style={styles.paragraph}>Normal checkbox</Text>
          </View>
        </View>
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  image: {
    width: "100%",
    height: 250,
  },
  container: {
    flex: 1,
    paddingBottom: 50,
  },
  button: {
    width: "32%",
    borderRadius: 20,
    height: 50,
    justifyContent: "center",
    alignItems: "center",
    padding: 10,
    backgroundColor: "#fc5c65",
  },
  buttonText: {
    fontSize: 15,
    color: "white",
  },
  detailsContainer: { padding: 20 },
  buttonContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginVertical: 15,
    width: "100%",
  },
  buttonContainer: {
    alignItems: "center",
    backgroundColor: "#ffffff",
    borderRadius: 5,
    marginHorizontal: 0,
    padding: 15,
    flexDirection: "row",
    justifyContent: "space-between",
  },

  title: {
    fontSize: 20,
    marginBottom: 10,
    color: "#FF595A",
    fontWeight: "bold",
  },
  subtitle: {
    fontSize: 17,
  },
  createdAt: {
    fontSize: 12,
    marginBottom: 6,
    color: "#555555",
  },
  logoText: {
    marginVertical: 5,
    fontSize: 10,
  },
});

export default ListingDetails;
