FROM node:alpine as builder

RUN apk update && apk add --no-cache make git

# Move our files into directory name "app"
WORKDIR /app
COPY ././frontend/package.json ././frontend/package-lock.json  /app/
RUN npm install @angular/cli@8.3.23 -g
RUN cd /app && npm set progress=false && npm install
COPY ././frontend/.  /app

# Build with $env variable from outside
RUN cd /app && npm run build

# Build a small nginx image with static website
FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*
COPY ./docker/frontend/config/nginx.conf /etc/nginx/nginx.conf
COPY --from=builder /app/dist/frontend /usr/share/nginx/html

EXPOSE 443

CMD ["nginx", "-g", "daemon off;"]