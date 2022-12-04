import React, { useState } from "react";
import bikeImg from "../assets/bike.png";

const ComponentsRegistration = () => {
  const [component, setComponent] = useState("");
  const [manufac, setManufac] = useState("");
  const [dates, setDates] = useState("");
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2  h-screen w-full ">
      <div className="hidden sm:block">
        <img className="w-full h-full object-contain" src={bikeImg} alt="" />
      </div>

      <div className="flex flex-col justify-center">
        <form
          // onSubmit={handleRegistration}
          className="max-w-[400px] w-full mx-auto bg-white p-4"
        >
          <h2 className="text-4xl font-bold text-center py-6">
            Register a component
          </h2>

          <div className="flex flex-col py-2">
            <label>Componenent name</label>
            <input
              type="text"
              placeholder="Componenent name"
              className="border p-2"
              value={component}
              onChange={(e) => setComponent(e.target.value)}
              required="required"
            />
          </div>
          <div className="flex flex-col py-2">
            <label>Manufacturer</label>
            <input
              type="text"
              placeholder="Manufacturer"
              className="border p-2"
              value={manufac}
              onChange={(e) => setManufac(e.target.value)}
              required="required"
            />
          </div>

          <div className="flex flex-col py-2">
            <label>Date Registered</label>
            <input
              type="date"
              placeholder="**********"
              className="border p-2"
              value={dates}
              onChange={(e) => setDates(e.target.value)}
              required="required"
            />
          </div>
          <button className="border w-full my-5 py-2 bg-indigo-600 hoover:bg-indigo-500 text-white">
            Register Component
          </button>
        </form>
      </div>
    </div>
  );
};

export default ComponentsRegistration;
