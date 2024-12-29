import React, { useState, useEffect } from "react";
import {
  Image,
  ScrollView,
  StyleSheet,
  Text,
  View,
  TouchableOpacity,
  Alert,
} from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

const ListingDetails = ({ route }) => {
  const [level, setLevel] = useState("beginner");
  const [isNewsSaved, setIsNewsSaved] = useState(false); // Is the news saved or not
  const [isLaterReadSaved, setIsLaterReadSaved] = useState(false); // Is the news saved for later reading

  // Function to get the level text
  const getLevelText = () => {
    if (!route.params) {
      return "Text not found"; // Default message
    }

    switch (level) {
      case "beginner":
        return route.params.beginner || "Beginner level content is not available.";
      case "intermediate":
        return route.params.intermediate || "Intermediate level content is not available.";
      case "advanced":
        return route.params.advanced || "Advanced level content is not available.";
      default:
        return route.params.beginner || "Beginner level content is not available.";
    }
  };

  // Check if the news has been saved in AsyncStorage
  const checkIfNewsSaved = async () => {
    try {
      const storedNews = await AsyncStorage.getItem("readNews");
      const updatedNews = storedNews ? JSON.parse(storedNews) : [];
      const isSaved = updatedNews.some(
        (item) => item.title === route.params?.title
      );
      setIsNewsSaved(isSaved);
    } catch (error) {
      console.error("Error checking saved news:", error);
    }
  };

  // Check if the news is saved for later reading in AsyncStorage
  const checkIfLaterReadSaved = async () => {
    try {
      const storedLaterRead = await AsyncStorage.getItem("laterReadNews");
      const updatedLaterRead = storedLaterRead ? JSON.parse(storedLaterRead) : [];
      const isSaved = updatedLaterRead.some(
        (item) => item.title === route.params?.title
      );
      setIsLaterReadSaved(isSaved);
    } catch (error) {
      console.error("Error checking saved later-read news:", error);
    }
  };

  // Save news to AsyncStorage
  const handleSaveNews = async () => {
    if (!route.params) {
      Alert.alert("News information is missing.");
      return;
    }

    const newsItem = {
      title: route.params.title,
      image: route.params.image,
      createdAt: route.params.createdAt,
      level: route.params.level,
      beginnerContent: route.params.beginner,
      intermediateContent: route.params.intermediate,
      advancedContent: route.params.advanced,
    };

    try {
      const storedNews = await AsyncStorage.getItem("readNews");
      let updatedNews = storedNews ? JSON.parse(storedNews) : [];

      if (updatedNews.find((item) => item.title === newsItem.title)) {
        Alert.alert("This news is already saved.");
        return;
      }

      updatedNews.push(newsItem);
      await AsyncStorage.setItem("readNews", JSON.stringify(updatedNews));
      Alert.alert("News successfully saved.");
      setIsNewsSaved(true);
    } catch (error) {
      console.error("Error saving news:", error);
      Alert.alert("Error saving news.");
    }
  };

  // Remove news from AsyncStorage
  const handleRemoveNews = async () => {
    try {
      const storedNews = await AsyncStorage.getItem("readNews");
      let updatedNews = storedNews ? JSON.parse(storedNews) : [];

      updatedNews = updatedNews.filter(
        (item) => item.title !== route.params?.title
      );

      await AsyncStorage.setItem("readNews", JSON.stringify(updatedNews));
      Alert.alert("News successfully removed from the list.");
      setIsNewsSaved(false);
    } catch (error) {
      console.error("Error removing news:", error);
      Alert.alert("Error removing news.");
    }
  };

  // Save news to "Later Read" list in AsyncStorage
  const handleSaveLaterReadNews = async () => {
    if (!route.params) {
      Alert.alert("News information is missing.");
      return;
    }

    const newsItem = {
      title: route.params.title,
      image: route.params.image,
      createdAt: route.params.createdAt,
      level: route.params.level,
      beginnerContent: route.params.beginner,
      intermediateContent: route.params.intermediate,
      advancedContent: route.params.advanced,
    };

    try {
      const storedLaterRead = await AsyncStorage.getItem("laterReadNews");
      let updatedLaterRead = storedLaterRead ? JSON.parse(storedLaterRead) : [];

      if (updatedLaterRead.find((item) => item.title === newsItem.title)) {
        Alert.alert("This news is already saved for later.");
        return;
      }

      updatedLaterRead.push(newsItem);
      await AsyncStorage.setItem("laterReadNews", JSON.stringify(updatedLaterRead));
      Alert.alert("News saved to Later Read list.");
      setIsLaterReadSaved(true);
    } catch (error) {
      console.error("Error saving news for later read:", error);
      Alert.alert("Error saving news for later read.");
    }
  };

  // Remove news from "Later Read" list
  const handleRemoveLaterReadNews = async () => {
    try {
      const storedLaterRead = await AsyncStorage.getItem("laterReadNews");
      let updatedLaterRead = storedLaterRead ? JSON.parse(storedLaterRead) : [];

      updatedLaterRead = updatedLaterRead.filter(
        (item) => item.title !== route.params?.title
      );

      await AsyncStorage.setItem("laterReadNews", JSON.stringify(updatedLaterRead));
      Alert.alert("News successfully removed from Later Read list.");
      setIsLaterReadSaved(false);
    } catch (error) {
      console.error("Error removing later-read news:", error);
      Alert.alert("Error removing news from Later Read list.");
    }
  };

  // Check if news is saved and saved for later on component mount
  useEffect(() => {
    checkIfNewsSaved();
    checkIfLaterReadSaved();
  }, []);

  useEffect(() => {
    if (route.params) {
      console.log("Parameters loaded:", route.params);
    } else {
      console.warn("Parameters not found.");
    }
  }, [route.params]);

  return (
    <View style={styles.container}>
      <ScrollView>
        {route.params?.image ? (
          <Image style={styles.image} source={{ uri: route.params.image }} />
        ) : (
          <Text style={styles.errorText}>Image not found.</Text>
        )}
        <View style={styles.detailsContainer}>
          <Text style={styles.title}>{route.params?.title || "No title"}</Text>
          <Text style={styles.createdAt}>
            Created at{" "}
            {route.params?.createdAt
              ? new Date(route.params.createdAt).toLocaleString("en-GB", {
                  day: "numeric",
                  month: "long",
                  year: "numeric",
                  hour: "2-digit",
                  minute: "2-digit",
                })
              : "Date not available"}
          </Text>

          <Text style={styles.subtitle}>{getLevelText()}</Text>

          {/* Level Selection */}
          <View style={styles.buttonContainer}>
            <TouchableOpacity
              style={[
                styles.button,
                level === "beginner" ? styles.selectedButton : styles.unselectedButton,
              ]}
              onPress={() => setLevel("beginner")}
            >
              <Text
                style={[
                  styles.buttonText,
                  level === "beginner" ? styles.selectedText : null,
                ]}
              >
                Beginner
              </Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[
                styles.button,
                level === "intermediate" ? styles.selectedButton : styles.unselectedButton,
              ]}
              onPress={() => setLevel("intermediate")}
            >
              <Text
                style={[
                  styles.buttonText,
                  level === "intermediate" ? styles.selectedText : null,
                ]}
              >
                Intermediate
              </Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[
                styles.button,
                level === "advanced" ? styles.selectedButton : styles.unselectedButton,
              ]}
              onPress={() => setLevel("advanced")}
            >
              <Text
                style={[
                  styles.buttonText,
                  level === "advanced" ? styles.selectedText : null,
                ]}
              >
                Advanced
              </Text>
            </TouchableOpacity>
          </View>

          <View style={styles.savedButtonContainer}>
            <TouchableOpacity
              style={[
                styles.button,
                isNewsSaved ? styles.savedButton : styles.unsavedButton,
              ]}
              onPress={isNewsSaved ? handleRemoveNews : handleSaveNews}
            >
              <Text
                style={[
                  styles.buttonText,
                  isNewsSaved ? styles.selectedText : null,
                ]}
              >
                {isNewsSaved ? "Mark as Unread" : "Mark as Read"}
              </Text>
            </TouchableOpacity>

            <TouchableOpacity
              style={[
                styles.button,
                isLaterReadSaved ? styles.savedButton : styles.unsavedButton,
              ]}
              onPress={isLaterReadSaved ? handleRemoveLaterReadNews : handleSaveLaterReadNews}
            >
              <Text
                style={[
                  styles.buttonText,
                  isLaterReadSaved ? styles.selectedText : null,
                ]}
              >
                {isLaterReadSaved ? "Remove from Reading List" : "Add to Reading List"}
              </Text>
            </TouchableOpacity>
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
  detailsContainer: { padding: 20 },
  buttonContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginVertical: 15,
    width: "100%",
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
  buttonText: {
    fontSize: 15,
    color: "white",
  },
  selectedButton: {
    backgroundColor: "#FFD3B6",
  },
  unselectedButton: {
    backgroundColor: "#fc5c65",
  },
  savedButton: {
    width: "45%",
    borderRadius: 25,
    height: 60,
    justifyContent: "center",
    alignItems: "center",
    padding: 10,
    backgroundColor: "#A8E6CF",
  },
  unsavedButton: {
    width: "45%",
    borderRadius: 25,
    height: 60,
    justifyContent: "center",
    alignItems: "center",
    padding: 10,
    backgroundColor: "#fc5c65",
  },
  selectedText: {
    color: "black",
  },
  errorText: {
    fontSize: 16,
    color: "red",
    textAlign: "center",
    marginVertical: 10,
  },
  savedButtonContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginVertical: 15,
    width: "100%",
  },
});

export default ListingDetails;
