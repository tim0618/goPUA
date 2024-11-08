import axios from "axios";

const login = async (data) => {
  try {
    const response = await axios.post("http://localhost:5218/api/User/Login", {
      account: data.account,
      password: data.password,
    });
    console.log(response.data);
  } catch (error) {
    console.error("Error during API call:", error);
  }
};

export default{
    login
}