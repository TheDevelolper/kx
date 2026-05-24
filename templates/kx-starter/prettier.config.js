/**
 * We're using Prettier config as a JavaScript file so that we can add comments to explain our
 * choices. It's also extensible in case we want to add more complex logic in the future.
 */

const config = {
  printWidth: 100,
  singleQuote: false,
  semi: true,
  trailingComma: "all",
  plugins: ["prettier-plugin-jsdoc"],
};

module.exports = config;
