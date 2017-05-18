//
//  MDPCompactContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCompactContentModel.h"


#pragma mark - Interface
@interface MDPCompactContentModel : _MDPCompactContentModel

+ (instancetype)compactContentWithId:(NSString *)idContent managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompactContentWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

- (NSString *)getFavoriteCountString;

@end



//#pragma mark - Content Types
//typedef NS_ENUM(NSInteger, MDPCompactContentModelContentType) {
//    MDPCompactContentModelContentTypeNews            = 0,
//    MDPCompactContentModelContentTypeVideos          = 1,
//    MDPCompactContentModelContentTypeFootBallNews    = 2,
//    MDPCompactContentModelContentTypeBasketNews      = 3,
//    MDPCompactContentModelContentTypeFootBallVideos  = 4,
//    MDPCompactContentModelContentTypeBasketVideos    = 5,
//    MDPCompactContentModelContentTypeGamesWindows    = 6,
//    MDPCompactContentModelContentTypeGamesWP         = 7,
//    MDPCompactContentModelContentTypeGamesIOS        = 8,
//    MDPCompactContentModelContentTypeGamesAndroid    = 9,
//    MDPCompactContentModelContentTypeResource        = 10,
//};
