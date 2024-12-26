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
  const [isNewsSaved, setIsNewsSaved] = useState(false); // Haber kaydedildi mi kontrolü

  // Seviye metnini döndüren fonksiyon
  const getLevelText = () => {
    if (!route.params) {
      return "Metin bulunamadı"; // Varsayılan mesaj
    }

    switch (level) {
      case "beginner":
        return route.params.beginner || "Başlangıç seviyesi metni mevcut değil.";
      case "intermediate":
        return route.params.intermediate || "Orta seviye metni mevcut değil.";
      case "advanced":
        return route.params.advanced || "İleri seviye metni mevcut değil.";
      default:
        return route.params.beginner || "Başlangıç seviyesi metni mevcut değil.";
    }
  };

  // Okunmuş haberleri AsyncStorage'den al ve kaydedilen haberin var olup olmadığını kontrol et
  const checkIfNewsSaved = async () => {
    try {
      const storedNews = await AsyncStorage.getItem("readNews");
      const updatedNews = storedNews ? JSON.parse(storedNews) : [];
      const isSaved = updatedNews.some(
        (item) => item.title === route.params?.title
      );
      setIsNewsSaved(isSaved);
    } catch (error) {
      console.error("Okunmuş haberler kontrol edilirken hata oluştu:", error);
    }
  };

  // Haberleri AsyncStorage'e kaydet
  const handleSaveNews = async () => {
    if (!route.params) {
      Alert.alert("Haber bilgileri eksik.");
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
        Alert.alert("Bu haber zaten kaydedildi.");
        return;
      }

      updatedNews.push(newsItem);
      await AsyncStorage.setItem("readNews", JSON.stringify(updatedNews));
      Alert.alert("Haber başarıyla kaydedildi.");
      setIsNewsSaved(true);
    } catch (error) {
      console.error("Haber kaydetme hatası:", error);
      Alert.alert("Haber kaydedilirken bir hata oluştu.");
    }
  };

  // Haberleri AsyncStorage'den çıkar
  const handleRemoveNews = async () => {
    try {
      const storedNews = await AsyncStorage.getItem("readNews");
      let updatedNews = storedNews ? JSON.parse(storedNews) : [];

      updatedNews = updatedNews.filter(
        (item) => item.title !== route.params?.title
      );

      await AsyncStorage.setItem("readNews", JSON.stringify(updatedNews));
      Alert.alert("Haber başarıyla listeden çıkarıldı.");
      setIsNewsSaved(false);
    } catch (error) {
      console.error("Haber çıkarma hatası:", error);
      Alert.alert("Haber çıkarılırken bir hata oluştu.");
    }
  };

  // Component yüklendiğinde haberin kaydedilip kaydedilmediğini kontrol et
  useEffect(() => {
    checkIfNewsSaved();
  }, []);

  useEffect(() => {
    if (route.params) {
      console.log("Parametreler yüklendi:", route.params);
    } else {
      console.warn("Parametreler bulunamadı.");
    }
  }, [route.params]);

  return (
    <View style={styles.container}>
      <ScrollView>
        {route.params?.image ? (
          <Image style={styles.image} source={{ uri: route.params.image }} />
        ) : (
          <Text style={styles.errorText}>Görsel bulunamadı.</Text>
        )}
        <View style={styles.detailsContainer}>
          <Text style={styles.title}>{route.params?.title || "Başlık yok"}</Text>
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
              : "Tarih bulunamadı"}
          </Text>

          <Text style={styles.subtitle}>{getLevelText()}</Text>

          {/* Level Selection */}
          <View style={styles.buttonContainer}>
            <TouchableOpacity
              style={[
                styles.button,
                level === "beginner"
                  ? styles.selectedButton
                  : styles.unselectedButton,
              ]}
              onPress={() => setLevel("beginner")}
            >
              <Text style={styles.buttonText}>Beginner</Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[
                styles.button,
                level === "intermediate"
                  ? styles.selectedButton
                  : styles.unselectedButton,
              ]}
              onPress={() => setLevel("intermediate")}
            >
              <Text style={styles.buttonText}>Intermediate</Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[
                styles.button,
                level === "advanced"
                  ? styles.selectedButton
                  : styles.unselectedButton,
              ]}
              onPress={() => setLevel("advanced")}
            >
              <Text style={styles.buttonText}>Advanced</Text>
            </TouchableOpacity>
          </View>

          <View style={styles.buttonContainer}>
            <TouchableOpacity
              style={styles.button}
              onPress={isNewsSaved ? handleRemoveNews : handleSaveNews}
            >
              <Text style={styles.buttonText}>
                {isNewsSaved
                  ? "Okunmuş Haberlerden Çıkar"
                  : "Haberi Listeye Kaydet"}
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
    backgroundColor: "#ffd1dc",
  },
  unselectedButton: {
    backgroundColor: "#fc5c65",
  },
  errorText: {
    fontSize: 16,
    color: "red",
    textAlign: "center",
    marginVertical: 10,
  },
});

export default ListingDetails;
