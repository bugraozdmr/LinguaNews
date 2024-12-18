import React from "react";
import { createStackNavigator } from "@react-navigation/stack";
import NewsFeed from "../component/NewsFeed";
import NewsInfo from "../component/NewsInfo";
import MyNews from "../component/MyNews";
const Stack = createStackNavigator();

function MyStack() {
  return (
    <Stack.Navigator
      screenOptions={{ headerShown: false }}
      initialRouteName="Home"
    >
      <Stack.Screen name="MyNewsPage" component={MyNews} />
      <Stack.Screen
        options={{ presentation: "modal" }}
        name="Info"
        component={NewsInfo}
      />
    </Stack.Navigator>
  );
}
export default MyStack;
