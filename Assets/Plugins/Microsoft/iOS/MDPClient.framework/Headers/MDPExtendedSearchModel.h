//
//  MDPExtendedSearchModel.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 23/8/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - Interface
@interface MDPExtendedSearchModel : NSObject

- (instancetype)initWithCompetition:(NSString *)competition
                             season:(NSString *)season
                         mainActors:(NSArray *)mainActors
                    matchEventTypes:(NSArray *)matchEventTypes
                                top:(NSInteger)top
                               skip:(NSInteger)skip
                         searchText:(NSString *)searchText
                           language:(NSString *)language;

- (NSString *)competition;

- (NSString *)season;

- (NSArray *)mainActors;

- (NSArray *)matchEventTypes;

- (NSInteger)top;

- (NSInteger)skip;

- (NSString *)searchText;

- (NSString *)language;

@end
