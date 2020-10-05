import {expect, test} from '@oclif/test'

import cmd = require('../src')

describe('test-ai', () => {
  test
  .stdout()
  .do(() => cmd.run([]))
  .it('requires a file', ctx => {
    expect(ctx.stdout).to.contain('File required')
  })
})
