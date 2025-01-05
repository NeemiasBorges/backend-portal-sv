import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { BrowserRouter, Routes, Route } from "react-router";
import ListChat from "./pages/chat/listChatPage.jsx";

createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="/chatbot" element={<ListChat />} />
      {/* <Route path="/configuracoes" element={<ListChat />} /> */}
    </Routes>
  </BrowserRouter>
);
