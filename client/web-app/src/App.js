import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import "./App.css";
import SignIn from "./components/SignIn";
import Register from "./components/Register";
import BikeRegistration from "./components/BikeRegistration";
import ComponentsRegistration from "./components/ComponentsRegistration";
import Home from "./components/Home";

function App() {
  return (
    <div>
      <Router>
        <Routes>
          <Route path="/" element={<SignIn />} />
          <Route path="/register" element={<Register />} />
          <Route path="/home" element={<Home />} />
          <Route path="/registerBike" element={<BikeRegistration />} />
          <Route path="/compRegister" element={<ComponentsRegistration />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
