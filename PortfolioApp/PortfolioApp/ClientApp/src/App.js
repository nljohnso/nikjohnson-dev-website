import React, { Component } from 'react';
import Particles from "react-tsparticles";
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import particlesOptions from "./particles.json";

export default class App extends Component {
    static displayName = App.name;

  render () {
    return (
        <div className="App">
            <Particles options={particlesOptions} />
        </div>
    );
  }
}
