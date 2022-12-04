import React, { useState } from "react";
import bikeImg from "../assets/bike.png";

const BikeRegistration = () => {
  const [bike, setBike] = useState("");
  const [motor, setMotor] = useState("");
  const [battery, setBattery] = useState("");
  const [wheels, setWheels] = useState("");
  const [gear, setGear] = useState("");
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
            Register a bike
          </h2>

          <div className="flex flex-col py-2">
            <label>Bike Type</label>
            <input
              type="text"
              placeholder="Bike type/name"
              className="border p-2"
              value={bike}
              onChange={(e) => setBike(e.target.value)}
              required="required"
            />
          </div>
          <div className="flex flex-col py-2">
            <label>Electric Motor</label>
            <input
              type="text"
              placeholder="Electric Motor"
              className="border p-2"
              value={motor}
              onChange={(e) => setMotor(e.target.value)}
              required="required"
            />
          </div>
          <div className="flex flex-col py-2">
            <label>Battery</label>
            <input
              type="text"
              placeholder="Battery"
              className="border p-2"
              value={battery}
              onChange={(e) => setBattery(e.target.value)}
              required="required"
            />
          </div>
          <div className="flex flex-col py-2">
            <label>Gear system</label>
            <input
              type="text"
              placeholder="Gear system"
              className="border p-2"
              value={gear}
              onChange={(e) => setGear(e.target.value)}
              required="required"
            />
          </div>
          <div className="flex flex-col py-2">
            <label>wheels</label>
            <input
              type="text"
              placeholder="Wheels"
              className="border p-2"
              value={wheels}
              onChange={(e) => setWheels(e.target.value)}
              required="required"
            />
          </div>
          <div className="flex flex-col py-2">
            <label>Date Created</label>
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
            Register Bike
          </button>
        </form>
      </div>
    </div>
  );
};

export default BikeRegistration;
