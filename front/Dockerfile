FROM node
WORKDIR /app
COPY front/package.json .
RUN npm install --legacy-peer-deps
COPY . .
EXPOSE 3000
CMD ["npm","start","--prefix", "front"]