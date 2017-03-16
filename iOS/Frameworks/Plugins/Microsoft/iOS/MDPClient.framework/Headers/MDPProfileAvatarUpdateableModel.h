//
//  MDPProfileAvatarUpdateableModel.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 11/3/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - Interface
@interface MDPProfileAvatarUpdateableModel : NSObject

#pragma mark - Method Add
- (void)addPhysicalPropertyWithType:(NSString *)type version:(NSString *)version data:(NSString *)data;

- (void)addAccesoryWithIdVirtualGood:(NSString *)idVirtualGood type:(NSString *)type version:(NSString *)version data:(NSString *)data;


#pragma mark - Methods Get
- (NSArray *)collectionProfileAvatarItem;

- (NSArray *)collectionProfileAvatarAccessoryItem;

@end
