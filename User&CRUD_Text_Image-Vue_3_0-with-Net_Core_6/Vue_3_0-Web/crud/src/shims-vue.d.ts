/* eslint-disable */
/* shim vue file: 使 Typescript好辨認每份vue檔案還有 component */
declare module '*.vue' {
  import type { DefineComponent } from 'vue'
  const component: DefineComponent<{}, {}, any>
  export default component
}
