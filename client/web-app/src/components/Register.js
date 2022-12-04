import React from "react";
import RegisterForm from "./RegisterForm";

import bikeImg from "../assets/bike.png";

const Register = () => {
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2  h-screen w-full">
      <div className="hidden sm:block">
        <img className="w-full h-full object-contain" src={bikeImg} alt="" />
      </div>

      <div className="flex flex-col justify-center">
        <h1 className="text-4xl font-bold text-center py-6">Create Account</h1>
        <RegisterForm />
      </div>
    </div>
  );
};

export default Register;
