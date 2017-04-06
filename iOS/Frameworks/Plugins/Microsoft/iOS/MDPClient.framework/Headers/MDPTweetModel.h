//
//  MDPTweetModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPTweetModel.h"


#pragma mark - Interface
@interface MDPTweetModel : _MDPTweetModel

+ (instancetype)insertIfNotExistsTweetWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
