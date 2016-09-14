//
//  MDPVideoPublicationChannelModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPVideoPublicationChannelModel.h"


#pragma mark - Interface
@interface MDPVideoPublicationChannelModel : _MDPVideoPublicationChannelModel

+ (instancetype)insertIfNotExistsVideoPublicationChannelWithDictionary:(NSDictionary *)dictionary  managedObjectContext:(NSManagedObjectContext *)context;

@end
