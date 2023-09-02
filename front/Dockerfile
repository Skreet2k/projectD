ARG NPM_CONFIG_LOGLEVEL=verbose

FROM node:20-alpine3.17 as deps
WORKDIR /build
ARG NPM_CONFIG_REGISTRY=""
ARG YARN_REGISTRY=""
COPY package.json ./
COPY yarn.lock ./
RUN yarn install

FROM deps as build
COPY . .
RUN yarn run build

FROM nginx:1.25.2-alpine
WORKDIR /var/www
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /build/build /var/www